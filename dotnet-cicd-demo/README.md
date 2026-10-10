# .NET CI/CD demo (GitHub Actions)

Flow: PR -> build/test/coverage gate -> SonarCloud quality gate -> security scans (gitleaks, NuGet vuln, dependency review, CodeQL)
Merge to main -> Docker build -> Trivy scan -> push ECR -> CD: staging -> smoke test -> prod (manual approval) -> auto rollback on failure.

## One-time setup
1. `dotnet new sln` + add projects (see DotnetCicdDemo.sln.txt)
2. GitHub repo Settings:
   - Secrets: SONAR_TOKEN
   - Variables: SONAR_ORG, SONAR_PROJECT_KEY, AWS_ROLE_ARN, AWS_REGION, ECR_REPOSITORY, EKS_CLUSTER, STAGING_URL, PROD_URL
   - Environments: staging, production (production -> Required reviewers)
3. Branch protection on main: require PR, require status checks (build-test, sonar, security), no direct push.
4. AWS: create IAM role with GitHub OIDC trust (repo-scoped) + ECR push + EKS access.
5. Enable GitHub Advanced Security / code scanning (free for public repos).
