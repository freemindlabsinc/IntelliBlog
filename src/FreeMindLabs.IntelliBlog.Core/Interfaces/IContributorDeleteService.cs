﻿using Ardalis.Result;

namespace FreeMindLabs.IntelliBlog.Core.Interfaces;

public interface IContributorDeleteService
{
    public Task<Result> DeleteContributor(int contributorId);    
}
