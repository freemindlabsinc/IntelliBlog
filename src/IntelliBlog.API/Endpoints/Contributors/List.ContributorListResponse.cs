using IntelliBlog.API.Endpoints.Contributors;

namespace IntelliBlog.Web.Contributors;

public class ContributorListResponse
{
  public List<ContributorRecord> Contributors { get; set; } = [];
}
