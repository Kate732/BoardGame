namespace BoardSite.Api.Models {
    public class CalculatorInput {
        public Operation Operation { get; set; }
        public Decimal Operand1 { get; set; }
        public Decimal Operand2 { get; set; }
    }

    public enum Operation {
        AddOperation, 
        SubstituteOperation, 
        MultiplyOperation
    }
}
