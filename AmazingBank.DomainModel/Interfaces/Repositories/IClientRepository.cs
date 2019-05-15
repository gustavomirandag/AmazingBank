using AmazingBank.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingBank.DomainModel.Interfaces.Repositories
{
    public interface IClientRepository : IRepository<Client,Guid>
    {
    }
}
