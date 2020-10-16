
public abstract class ValidationError
{
    public ValidationError(string message) 
    {
        Message = message;
    }
    string Message { get; set; }
}

public class ZeroOrLessDimensionValidationError : ValidationError
{
}

public class WrongTriangleDimensionsValidationError: ValidationError
{
}