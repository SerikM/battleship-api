using Amazon.Lambda.Core;
using System.Collections.Generic;
using System.Net;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using battleship.Models;
using battleship.Services;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace battleship
{
    public class Function
    {
        private const string ErrorMessage = "failed to process request";
        private const string SuccessMessage = "successfully to process request";
        private const string HitMessage = "hit";
        private const string MissMessage = "miss";


        private BattleFieldService _battlefieldService = new BattleFieldService();
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayProxyResponse InitializeGameHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var success = false;
            if (!string.IsNullOrEmpty(request?.Body))
            {
                var ship = JsonConvert.DeserializeObject<Ship>(request?.Body);
                if (ship != null)
                {
                    success= _battlefieldService.CreateNewBattlefield(ship);
                }
            }

            return success ? CreateResponse(SuccessMessage, success) : CreateResponse(ErrorMessage, success);
        }


        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public APIGatewayProxyResponse ShootHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            string hitMissMessage = string.Empty;
            var success = false;
            if (!string.IsNullOrEmpty(request?.Body))
            {
                var shot = JsonConvert.DeserializeObject<Shot>(request?.Body);
                if (shot != null)
                {
                   hitMissMessage  = _battlefieldService.MakeShot(shot) ? HitMessage : MissMessage;
                };
            }

            return success ? CreateResponse(hitMissMessage, success) : CreateResponse(ErrorMessage, success);
        }


        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="result"></param>
        /// <param name="success"></param>
        /// <returns>response</returns>
        APIGatewayProxyResponse CreateResponse(object result, bool success)
        {
            int statusCode = !success || result == null ? (int)HttpStatusCode.InternalServerError : (int)HttpStatusCode.OK;
            string body = statusCode == (int)HttpStatusCode.OK ? JsonConvert.SerializeObject(result) : string.Empty;

            var response = new APIGatewayProxyResponse
            {
                StatusCode = statusCode,
                Body = body,
                Headers = new Dictionary<string, string>
               {
                  { "Content-Type", "application/json" }
               }
            };

            return response;
        }
    }
}

