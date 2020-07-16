package graph

// This file will be automatically regenerated based on the schema, any resolver implementations
// will be copied through when generating and any unknown code will be moved to the end.

import (
	"context"
	"fmt"

	"github.com/uwec-innovation-labs/energy-dashboard-database-manipulation/graph/generated"
	"github.com/uwec-innovation-labs/energy-dashboard-database-manipulation/graph/model"
)

func (r *buildingDataResolver) EnergyTypes(ctx context.Context, obj *model.BuildingData) ([]string, error) {
	panic(fmt.Errorf("not implemented"))
}

func (r *queryResolver) BuildingEnergyData(ctx context.Context) (*model.BuildingEnergyData, error) {
	panic(fmt.Errorf("not implemented"))
}

func (r *queryResolver) BuildingData(ctx context.Context) (*model.BuildingData, error) {
	panic(fmt.Errorf("not implemented"))
}

// BuildingData returns generated.BuildingDataResolver implementation.
func (r *Resolver) BuildingData() generated.BuildingDataResolver { return &buildingDataResolver{r} }

// Query returns generated.QueryResolver implementation.
func (r *Resolver) Query() generated.QueryResolver { return &queryResolver{r} }

type buildingDataResolver struct{ *Resolver }
type queryResolver struct{ *Resolver }
