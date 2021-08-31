using HourChallenge.Storage;
using System.Collections.Generic;

namespace HourChallenge.Abstractions
{
    public interface IGameProgress
    {
        IList<Challenge> GetChallenges();

        Challenge GetChallenge(int challenge);

        void AddChallenge(Challenge challenge);

        void UpdateChallenge(Challenge challenge);

        void DeleteChallenge(int challenge);

        void ClearGameProgress();
    }
}
