﻿using Ardalis.Result;
using Ardalis.SharedKernel;

namespace FreeMindLabs.IntelliBlog.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
