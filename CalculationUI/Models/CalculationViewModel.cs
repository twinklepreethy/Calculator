namespace CalculationUI.Models
{
    public class CalculationViewModel
    {
        public IEnumerable<KeyValueViewModel> Functions { get; set; } = new List<KeyValueViewModel>();
        public int SelectedFunctionId { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public decimal Step { get; set; }
        public decimal ProbabilityA { get; set; }
        public decimal ProbabilityB { get; set; }
        public string ProbabilityAMinValueErrorMsg { get; set; } = string.Empty;
        public string ProbabilityAMaxValueErrorMsg { get; set; } = string.Empty;
        public string ProbabilityBMinValueErrorMsg { get; set; } = string.Empty;
        public string ProbabilityBMaxValueErrorMsg { get; set; } = string.Empty;
        public string EmptyFieldErrorMessage { get; set; } = string.Empty;
    }
}
