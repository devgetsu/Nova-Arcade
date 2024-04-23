﻿using Game_Store.Application.Abstractions;
using Game_Store.Domain.Entities;
using Game_Store.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Game_Store.Application.useCases.Games.Queries
{
    public class GetGameByIdQueryHanler : IRequestHandler<GetGameByIdQuery, Game>
    {
        private readonly IAppDbContext _appDbContext;

        public GetGameByIdQueryHanler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Game> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
        {
            var game = await _appDbContext.Games.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (game == null)
            {
                throw new NotFoundException("Game not found");
            }
            else
            {
                return game;
            }
        }
    }
}
