namespace UserApi.Models
{
    public class UserResult<T>
    {
        public UserResult(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;

        }

        public UserResult(T data)
        {
            Data = data;
        }

        public UserResult(List<string> errors)
        {
            Errors = errors;
        }

        public UserResult(string error)
        {
            Errors = new List<string> { error };
        }


        public T Data { get; private set; }
        public List<string> Errors { get; private set; } = new();

    }
}
