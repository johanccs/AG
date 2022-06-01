using AG.Common.Helpers;
using AG.Data.Contracts;
using AG.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AG.Data.Services
{
    public class UserBuilder : IUserBuilder
    {
        #region Readonly Fields

        private readonly IFileReader _fileReader;

        #endregion

        #region Constants

        private const string FOLLOWS = "follows";

        #endregion

        #region Ctor

        public UserBuilder(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        #endregion

        #region Methods

        public IList<User> Build(string filePath)
        {
            var lines = ReadLines(filePath);

            return BuildUsers(lines);
        }

        #endregion

        #region Private Methods

        private IList<User>BuildUsers(IList<string> lines)
        {
            var users = new List<User>();

            lines.ToList().ForEach(x =>
            {
                var user = BuildUser(x);

                if (user != null)
                {
                    users.Add(user);
                }
            });

            return users;
        }

        private User BuildUser(string user)
        {
            if (!StringHelper.Contains(user, FOLLOWS))
                throw new ArgumentException("Invalid user");

            var results = user.Split(FOLLOWS);

            if(results.Length > 1)
            {
                return new User(results[0], results[1]);
            }

            return null;
        }

        private IList<string>ReadLines(string filePath)
        {
            var lines = _fileReader.Read(filePath);

            return lines;
        }

        #endregion
    }
}
