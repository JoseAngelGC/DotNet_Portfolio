using ApiMovieStoreDemo1_Net5.Data;
using ApiMovieStoreDemo1_Net5.Helpers.IHelpers;
using ApiMovieStoreDemo1_Net5.Models;
using ApiMovieStoreDemo1_Net5.Models.Response.RepositoryResponses.UserAuthRepositoryResponses;
using ApiMovieStoreDemo1_Net5.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMovieStoreDemo1_Net5.Repository
{
    public class UserAuthRepository : IUserAuthRepository
    {
        private readonly AppDbContext _db;
        private readonly IUserAuthRepositoryHelpers _iurh;
        public UserAuthRepository(AppDbContext db, IUserAuthRepositoryHelpers iUserAuthRepositoryHelpers)
        {
            _db = db;
            _iurh = iUserAuthRepositoryHelpers;
        }

        public Task<ExistUserAuthRepositoryResponse> ExistUserAuth(string userAlias)
        {
            try
            {
                bool existUserAuth = _db.UsersAuth.Any(u => u.AliasUser == userAlias);
                return Task.FromResult(_iurh.ExistUserAuthRepositoryResponseHelper(1, null, existUserAuth));
            }
            catch (Exception ex)
            {
                return Task.FromResult(_iurh.ExistUserAuthRepositoryResponseHelper(-1, ex.Message, false));
            }
        }

        public async Task<UserAuthRepositoryResponse> GetUserAuthByAlias(string userAlias)
        {
            try
            {
                var userAuthData = await _db.UsersAuth.FirstOrDefaultAsync(u => u.AliasUser == userAlias);
                return _iurh.UserAuthRepositoryResponseHelper(1, null, userAuthData);
            }
            catch (Exception ex)
            {
                return _iurh.UserAuthRepositoryResponseHelper(-1, ex.Message, null);
            }
        }

        public async Task<UserAuthListRepositoryResponse> GetUsersAuth()
        {
            try
            {
                var userAuthList = await _db.UsersAuth.ToListAsync();
                return _iurh.UsersAuthRepositoryResponseHelper(1, null, userAuthList);
            }
            catch (Exception ex)
            {
                return _iurh.UsersAuthRepositoryResponseHelper(-1, ex.Message, null);
            }
        }

        public async Task<UserAuthRepositoryResponse> RegisterUserAuth(UserAuth userAuth)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.UsersAuth.Add(userAuth);
                    await _db.SaveChangesAsync();
                    transaction.Commit();
                    return _iurh.UserAuthRepositoryResponseHelper(1, null);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return _iurh.UserAuthRepositoryResponseHelper(-1, ex.Message);
                }
            }
        }
    }
}
