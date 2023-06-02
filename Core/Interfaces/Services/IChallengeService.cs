using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTO.ChallengeDTO;
using ChallengeDTO = Core.DTO.ChallengeDTO.ChallengeDTO;
using CreateChallengeDTO = Core.DTO.ChallengeDTO.CreateChallengeDTO;
using UpdateChallengeDTO = Core.DTO.ChallengeDTO.UpdateChallengeDTO;

namespace Core.Interfaces.Services;

public interface IChallengeService
{
    Task<IList<ChallengeDTO>> GetAllChallengesByUser(string userId);
    Task AddChallenge(string userId, CreateChallengeDTO createChallengeDto);
    Task UpdateChallenge(string userId, UpdateChallengeDTO updateChallengeDto);
    Task DeleteChallenge(int challengeId);
    Task<ChallengeDTO> GetChallengeById(int challengeId);
    Task<List<StatisticsGeneralDTO>> GetStatisticsAsync(string userId);
    Task<List<StatisticsGeneralDTO>> GetStatisticsAsync(int challengeId);
}