package model

type BuildingData struct {
	Building    string `json:"building"`
	MaxDate     int    `json:"maxdate"`
	MinDate     int    `json:"mindate"`
	EnergyTypes string `json:"energytypes"`
}
