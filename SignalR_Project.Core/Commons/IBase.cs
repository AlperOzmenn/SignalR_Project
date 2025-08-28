
namespace SignalR_Project.Core.Commons
{
    public interface IBase
    {
        Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        bool IsDeleted { get; set; }
        void SoftDelete();
        void Restore();
    }
}
