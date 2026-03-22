# React + TypeScript + Vite

This template provides a minimal setup to get React working in Vite with HMR and some ESLint rules.

Currently, two official plugins are available:

- [@vitejs/plugin-react](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react) uses [Oxc](https://oxc.rs)
- [@vitejs/plugin-react-swc](https://github.com/vitejs/vite-plugin-react/blob/main/packages/plugin-react-swc) uses [SWC](https://swc.rs/)

## React Compiler

The React Compiler is not enabled on this template because of its impact on dev & build performances. To add it, see [this documentation](https://react.dev/learn/react-compiler/installation).

## Expanding the ESLint configuration

If you are developing a production application, we recommend updating the configuration to enable type-aware lint rules:

```js
export default defineConfig([
  globalIgnores(['dist']),
  {
    files: ['**/*.{ts,tsx}'],
    extends: [
      // Other configs...

      // Remove tseslint.configs.recommended and replace with this
      tseslint.configs.recommendedTypeChecked,
      // Alternatively, use this for stricter rules
      tseslint.configs.strictTypeChecked,
      // Optionally, add this for stylistic rules
      tseslint.configs.stylisticTypeChecked,

      // Other configs...
    ],
    languageOptions: {
      parserOptions: {
        project: ['./tsconfig.node.json', './tsconfig.app.json'],
        tsconfigRootDir: import.meta.dirname,
      },
      // other options...
    },
  },
])
```

You can also install [eslint-plugin-react-x](https://github.com/Rel1cx/eslint-react/tree/main/packages/plugins/eslint-plugin-react-x) and [eslint-plugin-react-dom](https://github.com/Rel1cx/eslint-react/tree/main/packages/plugins/eslint-plugin-react-dom) for React-specific lint rules:

```js
// eslint.config.js
import reactX from 'eslint-plugin-react-x'
import reactDom from 'eslint-plugin-react-dom'

export default defineConfig([
  globalIgnores(['dist']),
  {
    files: ['**/*.{ts,tsx}'],
    extends: [
      // Other configs...
      // Enable lint rules for React
      reactX.configs['recommended-typescript'],
      // Enable lint rules for React DOM
      reactDom.configs.recommended,
    ],
    languageOptions: {
      parserOptions: {
        project: ['./tsconfig.node.json', './tsconfig.app.json'],
        tsconfigRootDir: import.meta.dirname,
      },
      // other options...
    },
  },
])
```

## File Structure of this project
```
discover-map/
│
├─ discovermap.client/         # React frontend
│   ├─ public/
│   ├─ src/
│   │   ├─ components/         # Reusable components (Map, PinCard, Filters, Heatmap)
│   │   ├─ pages/              # Main pages (Home, AddPin, PinDetail)
│   │   ├─ hooks/              # Custom React hooks (usePins, useFilter)
│   │   ├─ utils/              # Helpers (distance calculation, formatting)
│   │   ├─ assets/             # Images, icons, styles
│   │   ├─ services/           # API calls (pinsService.js)
│   │   └─ App.js
│   └─ package.json
│
├─ DiscoverMap.Server/         # C# ASP.NET Core Web API backend
│   ├─ Controllers/            # API controllers (PinController.cs, UserController.cs)
│   ├─ Models/                 # DB models / entity classes (Pin.cs, User.cs)
│   ├─ Services/               # Business logic (PinService.cs, GeoService.cs)
│   ├─ DTOs/                   # Data transfer objects (PinDTO.cs)
│   ├─ Repositories/           # Data access layer (PinRepository.cs)
│   ├─ Migrations/             # Database migrations (EF Core)
│   ├─ Helpers/                # Utility functions (GeoHelper.cs, FileUploadHelper.cs)
│   ├─ appsettings.json        # Config for DB & Supabase keys
│   └─ Program.cs + Startup.cs # Entry point & middleware setup
│
├─ supabase/                    # Optional: Supabase scripts / config
│   └─ supabaseClient.cs        # Supabase real-time setup (if using subscriptions)
│
├─ scripts/                     # Solo testing / pin simulators
│   ├─ fakePinsGenerator.cs     # Generates fake pins for testing
│   └─ seedDatabase.cs          # Seed initial pins/users
│
├─ docker/                      # Docker config for all services
│   ├─ client.Dockerfile
│   ├─ server.Dockerfile
│   ├─ docker-compose.yml       # Compose for React + API + PostgreSQL
│
├─ README.md
└─ .env                         # Environment variables (API keys, DB connection)
```