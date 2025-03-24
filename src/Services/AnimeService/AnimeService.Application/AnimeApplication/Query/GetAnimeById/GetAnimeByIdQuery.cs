using AnimeService.Domain.AnimeAggregate.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SharedKernel.CQRS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AnimeService.Application.AnimeApplication.Query.GetAnimeById;

public record GetAnimeByIdQuery(Guid AnimeId) : IQuery<AnimeRecordResponse?>;

