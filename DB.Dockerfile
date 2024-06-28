# Use the official Microsoft SQL Server image from Docker Hub
FROM mcr.microsoft.com/mssql/server:2022-latest

# Set environment variables
ENV SA_PASSWORD=P@ssw0rd
ENV ACCEPT_EULA=Y

# Expose the SQL Server port
EXPOSE 1433
