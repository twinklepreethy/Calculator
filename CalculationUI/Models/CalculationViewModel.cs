namespace CalculationUI.Models
{
    public class CalculationViewModel
    {
        public IEnumerable<KeyValueViewModel> Functions { get; set; }
        public int SelectedFunction { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public decimal Step { get; set; }
        public decimal Value { get; set; }
    }
}
