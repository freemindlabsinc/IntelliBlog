using IntelliBlog.API.Endpoints.Contributors;

namespace IntelliBlog.Web.Contributors;

public class UpdateContributorResponse(ContributorRecord contributor)
{
  public ContributorRecord Contributor { get; set; } = contributor;
}
