namespace BoardSite.Api.Models {
    public class CalculatorResult {
        public Decimal Result { get; set; }
        public bool HasError { get; set; }
        public string? ErrorText { get; set; }
    }
}
