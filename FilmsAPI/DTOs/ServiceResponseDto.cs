namespace FilmsAPI.DTOs
{
    public class ServiceResponseDto
    {
        public ServiceResponseDto(List<string> errors)
        {
            Errors = errors;
        }

        public ServiceResponseDto(object value)
        {
            Errors = new List<string>();
            Value = value;
        }

        public IList<string> Errors { get; private set; }
        public object? Value { get; private set; }
        public bool IsValid { get { return Errors.Count() == 0; } }
    }
}
