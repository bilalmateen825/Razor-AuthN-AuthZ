using Microsoft.AspNetCore.Authorization;

namespace Authentication_Authorization
{
    public class EmployeeProbationRequirement: IAuthorizationRequirement
    {
        public int ProbationMonths { get; set; }
        public EmployeeProbationRequirement(int probationMonths)
        {
            ProbationMonths = probationMonths;
        }
    }

    public class EmployeeProbationRequirementHandler:AuthorizationHandler<EmployeeProbationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmployeeProbationRequirement requirement)
        {            
            if (!context.User.HasEmployementDate())
                return Task.CompletedTask;

            var empDate = DateTime.Parse(context.User.FindFirst(x => x.Type == Constants.EmployementDateClaimName).Value);
            var period = DateTime.Now - empDate;

            if (period.Days > 30 * requirement.ProbationMonths)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
