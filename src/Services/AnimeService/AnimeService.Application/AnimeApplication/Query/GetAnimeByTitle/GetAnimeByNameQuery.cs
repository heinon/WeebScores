using AnimeService.Domain.AnimeAggregate.ValueObjects;
using SharedKernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeService.Application.AnimeApplication.Query.GetAnimeByTitle;

public record GetAnimeByNameQuery(string Name) : IQuery<AnimeRecordResponse?>;
