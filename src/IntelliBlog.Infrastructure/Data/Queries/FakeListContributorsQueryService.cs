﻿using IntelliBlog.UseCases.Contributors;
using IntelliBlog.UseCases.Contributors.List;

namespace IntelliBlog.Infrastructure.Data.Queries;

public class FakeListContributorsQueryService : IListContributorsQueryService
{
  public Task<IEnumerable<ContributorDTO>> ListAsync()
  {
    List<ContributorDTO> result =
        [new ContributorDTO(1, "Fake Contributor 1", ""),
        new ContributorDTO(2, "Fake Contributor 2", "")];

    return Task.FromResult(result.AsEnumerable());
  }
}
