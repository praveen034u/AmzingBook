namespace IssueManagementService.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string CustomerId { get; set; }
        public int NumberOfCopies { get; set; }
    }
}
