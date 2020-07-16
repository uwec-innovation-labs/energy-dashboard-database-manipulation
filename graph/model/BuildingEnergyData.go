package model

type BuildingEnergyData struct {
	EnergyData []EnergyData `json:"energydata"`
	MaxDate    int          `json:"maxdate"`
	MinDate    int          `json:"mindate"`
	Building   string       `json:"building"`
	EnergyType string       `json:"energytype"`
}
