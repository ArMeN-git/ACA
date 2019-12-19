namespace CSVReader_LINQ
{
    class Car
    {
        public int ModelYear { get; set; }
        public string Division { get; set; }
        public string Carline { get; set; }
        public double EngDispl { get; set; }
        public int Cylinders { get; set; }
        public int CityFE { get; set; }
        public int HwyFE { get; set; }
        public int CombinedFE { get; set; }

        public Car()
        {

        }
        public Car(string carDetails)
        {
            string[] fields = carDetails.Split(',');
            this.ModelYear = int.Parse(fields[0]);
            this.Division = fields[1];
            this.Carline = fields[2];
            this.Cylinders = int.Parse(fields[4]);
            this.CityFE = int.Parse(fields[5]);
            this.HwyFE = int.Parse(fields[6]);
            this.CombinedFE = int.Parse(fields[7]);
        }
    }
}
