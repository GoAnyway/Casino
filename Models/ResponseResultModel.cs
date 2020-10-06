namespace Models
{
    public abstract class ResponseResultModel
    {
        public bool Success { get; set; }
        public ErrorModel Error { get; set; }
    }
}