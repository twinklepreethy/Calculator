namespace CalculationUI.Models
{
    public class CalculationViewModel
    {
        public IEnumerable<KeyValueViewModel> Functions { get; set; } = new List<KeyValueViewModel>();
        public int SelectedFunctionId { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public decimal Step { get; set; }
        public decimal Value { get; set; }
        public decimal ProbabilityA { get; set; }
        public decimal ProbabilityB { get; set; }
    }
}
