import globals from "globals";
import path from "node:path";
import { fileURLToPath } from "node:url";
import js from "@eslint/js";
import { FlatCompat } from "@eslint/eslintrc";
import typescriptParser from "@typescript-eslint/parser";
import typescriptPlugin from "@typescript-eslint/eslint-plugin";

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);
const compat = new FlatCompat({
    baseDirectory: __dirname,
    recommendedConfig: js.configs.recommended,
    allConfig: js.configs.all,
});

compat.extends("plugin:@typescript-eslint/recommended");
export default [
    ...compat.extends("eslint:recommended", "plugin:@typescript-eslint/recommended"),
    {
        languageOptions: {
            parser: typescriptParser,
            parserOptions: {
                project: "./tsconfig.json",
                tsconfigRootDir: __dirname,
                ecmaVersion: 12,
                sourceType: "module",
            },
            globals: {
                ...globals.browser,
                ...globals.k6,
            },
        },
        plugins: {
            "@typescript-eslint": typescriptPlugin,
        },
        rules: {
            "import/no-unresolved": 0,
            "no-restricted-globals": 0,
            "import/extensions": 0,
            "no-prototype-builtins": 0,
            semi: 0,
            "@typescript-eslint/no-unused-vars": ["error"],
            "@typescript-eslint/explicit-function-return-type": ["error"],
        },
    },
    {
        ignores: ["dist/**/*", "**/*.js"],
    }
];