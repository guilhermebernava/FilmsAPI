namespace FilmsAPI.DTOs
{
    public class ServiceResponseDto<T>
    {
        public ServiceResponseDto(List<string> errors)
        {
            Errors = errors;
        }

        public ServiceResponseDto(T value)
        {
            Errors = new List<string>();
            Value = value;
        }

        public IList<string> Errors { get; private set; }
        public T? Value { get; private set; }
        public bool IsValid { get { return Errors.Count() == 0; } }
    }
}
