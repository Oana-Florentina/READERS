﻿using Lunatic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunatic.Application.Persistence
{
    public interface IBookClubRepository: IAsyncRepository<BookClub>
    {
        Task<bool> ExistsByTitleAsync(string username);
        Task<bool> ExistById(Guid bookClubId);
    }
}
