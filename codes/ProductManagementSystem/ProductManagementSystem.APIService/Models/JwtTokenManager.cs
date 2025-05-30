using Microsoft.IdentityModel.Tokens;
using ProductManagementSystem.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductManagementSystem.APIService.Models
{
    public class JwtTokenManager(IConfiguration configuration) : ITokenManager
    {
        public string GenerateJSONWebToken(User user)
        {
            try
            {
                //genereate a summetric key for signing the token later
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"] ?? "productmanagementapiserverissuerkeyforjwttoken"));

                //genereate a credential which contains both the summetric key and name of a symmetric key algorithm for signing the token later
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                //create claims for the Jwt payload
                var claims = new[]
                {
                    new Claim(
                        type:JwtRegisteredClaimNames.Sub,
                        value:user.UserId
                        ),
                    new Claim(
                        type:JwtRegisteredClaimNames.Email, 
                        user.UserId
                        ),
                    new Claim(
                        type:JwtRegisteredClaimNames.Jti,
                        value:new Guid().ToString()
                        )
                };

                //generate the token using the payload (with claims), header and some more information and then sign the token by the sigining credential created earlier

                var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credentials,
                    claims: claims
                    );

                //serialize the token

                //WriteToken method: Serializes a JwtSecurityToken into a JWT in Compact Serialization Format. [A JWE or JWS in 'Compact Serialization Format'.]
                var jwtHandler = new JwtSecurityTokenHandler();
                var serializedToken = jwtHandler.WriteToken(token);
                return serializedToken;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
