﻿using Amazon;
using Amazon.Athena;
using System;
using System.Collections.Generic;
using System.Text;

namespace AthenaNetCore.BusinessLogic.Repositories
{
    public abstract class BaseRepository : IDisposable
    {
        public BaseRepository()
        {
            //Option 1: Use the default credential provider chain (recommended)
            // to learn more check: https://docs.aws.amazon.com/sdk-for-net/v3/developer-guide/net-dg-config-creds.html
            AmazonAthenaClient = new AmazonAthenaClient(RegionEndpoint.USWest2);

            //Option 1: Hardcode
            //Uncomment if you prefer hardcode your Access key and Secret access instead of using the environment variable
            //AmazonAthenaClient = new AmazonAthenaClient("YOUR_AWS_ACCESS_KEY", "YOUR_AWS_SECRET_ACCESS", RegionEndpoint.USWest2);
        }

        /// <summary>
        /// Instance of the client to be used by repository 
        /// classes to interact with Amazon Athena 
        /// </summary>
        internal IAmazonAthena AmazonAthenaClient { get; }

        /// <summary>
        /// Release compute resources alocated
        /// </summary>
        public void Dispose()
        {
            if (AmazonAthenaClient != null)
            {
                AmazonAthenaClient.Dispose();
            }
        }
    }
}