﻿using AG.Common.Enums;
using AG.Common.Helpers;
using AG.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AG.Data.Services.Helper;

namespace AG.Data.Services
{
    public class TweetManager : ITweetManager
    {
        #region Readonly Fields

        private readonly ITweetBuilder _tweetBuilder;
        private readonly IUserBuilder _userBuilder;
      
        #endregion

        #region Fields

        private string _filePath = @"C:\Tutorials\AG\Docs\";

        #endregion

        #region Ctor

        public TweetManager(ITweetBuilder tweetBuilder, IUserBuilder userBuilder)
        {
            _tweetBuilder = tweetBuilder;
            _userBuilder = userBuilder;          
        }

        #endregion

        #region Methods

        public async Task<bool> Run()
        {
            try
            {
                DisplayGeneralOutput.PrintWelcomeMessage();

                //2. Build List of internal users and followers
                var internalUserFile = FileHelper.BuildFilePath(_filePath, ApplicationEnum.USERFILE);
                var users = _userBuilder.Build(internalUserFile);

                //4. Build a list of tweets
                var internalTweetFile = FileHelper.BuildFilePath(_filePath, ApplicationEnum.TWEETFILE);
                var tweets = _tweetBuilder.Build(internalTweetFile);

                //5. Iterate through list of users
                TweetManagerHelper.IterateThroughUsers(users, tweets);

                DisplayGeneralOutput.PrintMessageFooter();

                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }

        #endregion
    }
}
