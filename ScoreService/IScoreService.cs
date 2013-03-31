using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ScoreService
{
    [ServiceContract]
    public interface IScoreService
    {
        [OperationContract]
        List<ScoreEntry> GetLeaderboard();

        [OperationContract]
        bool AddScore(string name, int score);
    }
}
