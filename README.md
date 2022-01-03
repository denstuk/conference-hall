![GitHub Workflow Status](https://img.shields.io/github/workflow/status/denstuk/conference-hall/backend-ci?label=Backend%20Build)
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/denstuk/conference-hall/web-ci?label=Web%20Build)
![Lines of code](https://img.shields.io/tokei/lines/github/denstuk/conference-hall?label=Total)
![GitHub language count](https://img.shields.io/github/languages/count/denstuk/conference-hall?label=Languages)

# ConferenceHall

Communication platform with real-time chatting (Asp.NET Pet Project) 

## Installation

```bash
git clone https://github.com/denstuk/conference-hall.git
cd backend && dotnet restore
cd web && npm i
```

## Usage

Run backend
```bash
cd backend && dotnet run
```

Run frontend
```bash
cd web && npm run start
```

## Structure

- backend: server side application (C#, ASP.NET Core, EF, SignalR)  
- web: web application (TypeScript, React.js)
- docker: development containers (PostgreSQL)
