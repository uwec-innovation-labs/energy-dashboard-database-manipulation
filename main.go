package main

import (
	"encoding/json"
	"fmt"
	"log"
	"net/http"

	"github.com/graphql-go/graphql"
)

type EnergyR struct {
	Value      int    `json:"value"`
	DateH      int64  `json:"dateh"` // int64 epoch time
	DateL      int64  `json:"datel"` // int64 epoch time
	Building   string `json:"building"`
	EnergyType string `json:"energytype"`
}

type EnergyDate struct {
	LargestDate  int64  `json:"largestdate"`
	SmallestDate int64  `json:"smallestdate"`
	EnergyType   string `json:"energytype"`
	DataError    bool   `json:"dataerror"`
}

type BuildingInfo struct {
	Building    string       `json:"building"`
	EnergyDates []EnergyDate `json:"energydates"`
}

func main() {
	EnergyRType := graphql.NewObject(graphql.ObjectConfig{
		Name: "energy",
		Fields: graphql.Fields{
			"value": &graphql.Field{
				Type: graphql.Int,
			},
			"dateh": &graphql.Field{
				Type: graphql.Int,
			},
			"datel": &graphql.Field{
				Type: graphql.Int,
			},
			"building": &graphql.Field{
				Type: graphql.String,
			},
			"energytype": &graphql.Field{
				Type: graphql.String,
			},
		},
	})

	EnergyDateType := graphql.NewObject(graphql.ObjectConfig{
		Name: "energydate",
		Fields: graphql.Fields{
			"largestdate": &graphql.Field{
				Type: graphql.Int,
			},
			"smallestdate": &graphql.Field{
				Type: graphql.Int,
			},
			"energytype": &graphql.Field{
				Type: graphql.String,
			},
			"dataerror": &graphql.Field{
				Type: graphql.Boolean,
			},
		}
	})

	BuildingInfoType := graphql.NewObject(graphql.ObjectConfig{
		Name: "buildinginfo",
		Fields: graphql.Fields{
			"building": &graphql.Field{
				Type: graphql.String,
			},
			"energydates": &graphql.Field{
				Type: graphql.NewList(EnergyDateType)
			},
		}
	})

	rootMutation := graphql.ObjectConfig(graphql.ObjectConfig{
		Name: "RootMutation",
		Fields: graphql.Fields{
			"TemplateMutation": &graphql.Field{
				Type:        graphql.Boolean,
				Description: "its a template",
				Args: graphql.FieldConfigArgument{
					"fieldname1": &graphql.ArgumentConfig{
						Type: graphql.NewNonNull(graphql.String),
					},
					"fieldname2": &graphql.ArgumentConfig{
						Type: graphql.NewNonNull(graphql.String),
					},
					"fieldname3": &graphql.ArgumentConfig{
						Type: graphql.NewNonNull(graphql.String),
					},
				},
				Resolve: func(params graphql.ResolveParams) (interface{}, error) {
					/* your resolver here! */

					return true, nil
				},
			},
		},
	})

	rootQuery := graphql.ObjectConfig(graphql.ObjectConfig{
		Name: "RootQuery",
		Fields: graphql.Fields{
			"EnergyKW": &graphql.Field{
				Type:        graphql.NewList(EnergyRType),
				Description: "returns array of kw energy values",
				Args: graphql.FieldConfigArgument{
					"building": &graphql.ArgumentConfig{
						Type: graphql.NewNonNull(graphql.String),
					},
					"dateh": &graphql.ArgumentConfig{
						Type: graphql.NewNonNull(graphql.String),
					},
					"datel": &graphql.ArgumentConfig{
						Type: graphql.NewNonNull(graphql.String),
					},
				},
				Resolve: func(params graphql.ResolveParams) (interface{}, error) {
					building := params.Args["building"].(string)
					dateh := params.Args["dateh"].(int64)
					datel := params.Args["datel"].(int64)

					//TODO: call DB query

					returnValue := EnergyR{
						Building: building,
						DateH:    dateh,
						DateL:    datel,
					}

					return returnValue, nil
				},
			},
			"EnergyKWH": &graphql.Field{
				Type:        graphql.NewList(EnergyRType),
				Description: "returns array of kw energy values",
				Args: graphql.FieldConfigArgument{
					"building": &graphql.ArgumentConfig{
						Type: graphql.NewNonNull(graphql.String),
					},
					"dateh": &graphql.ArgumentConfig{
						Type: graphql.NewNonNull(graphql.String),
					},
					"datel": &graphql.ArgumentConfig{
						Type: graphql.NewNonNull(graphql.String),
					},
				},
				Resolve: func(params graphql.ResolveParams) (interface{}, error) {
					building := params.Args["building"].(string)
					dateh := params.Args["dateh"].(int64)
					datel := params.Args["datel"].(int64)

					//TODO: call DB query

					returnValue := EnergyR{
						Building: building,
						DateH:    dateh,
						DateL:    datel,
					}

					return returnValue, nil
				},
			},
			"BuildingInfo": &graphql.Field{
				Type:        BuildingInfoType,
				Description: "returns energy types available for specified building and the possible date ranges",
				Args: graphql.FieldConfigArgument{
					"building": &graphql.ArgumentConfig{
						Type: graphql.NewNonNull(graphql.String),
					},
				},
				Resolve: func(params graphql.ResolveParams) (interface{}, error) {
					building := params.Args["building"].(string)

					//TODO: call DB query

					returnValue := BuildingInfo{}

					return returnValue, nil
				},
			},
		},
	})
	schemaConfig := graphql.SchemaConfig{
		Query:    graphql.NewObject(rootQuery),
		Mutation: graphql.NewObject(rootMutation),
	}
	schema, err := graphql.NewSchema(schemaConfig)

	if err != nil {
		log.Fatalf("failed to create new schema, error: %v", err)
	}

	http.HandleFunc("/graphql", func(w http.ResponseWriter, r *http.Request) {
		setupResponse(&w, r)
		if (*r).Method == "OPTIONS" {
			return
		}
		result := executeQuery(r.URL.Query().Get("query"), schema)
		json.NewEncoder(w).Encode(result)

	})
	http.ListenAndServe(":4000", nil)
}

func executeQuery(query string, schema graphql.Schema) *graphql.Result {
	result := graphql.Do(graphql.Params{
		Schema:        schema,
		RequestString: query,
	})
	if len(result.Errors) > 0 {
		fmt.Printf("wrong result, unexpected errors: %v", result.Errors)
	}
	return result
}
func setupResponse(w *http.ResponseWriter, req *http.Request) {
	(*w).Header().Set("Access-Control-Allow-Origin", "*")
	(*w).Header().Set("Access-Control-Allow-Methods", "POST, GET, OPTIONS, PUT, DELETE")
	(*w).Header().Set("Access-Control-Allow-Headers", "Accept, Content-Type, Content-Length, Accept-Encoding, X-CSRF-Token, Authorization")
}
