import { sleep } from "k6";
import { browser } from "k6/browser";
import { config } from "../config/settings.ts";
import { TokenInfo, User } from "../types/index.ts";

/**
 * Logs in a user and returns the token information, browser page, and browser context.
 * @param {Object} users - An object containing user information.
 * @param {string} vuID - The ID of the user.
 * @returns {Object} - An object containing the token information, browser page, and browser context.
 * @throws {Error} - If login fails.
 */
export async function login(
    users: User[],
    vuID: number
): Promise<{
    tokenInfo: TokenInfo;
}> {
    const ctx = await browser.newContext({
        permissions: ["microphone", "notifications"],
    });
    const page = await ctx.newPage();
    console.log(page);
    const user = users[vuID];
    try {
        await page.goto(config.appUrl);
        page.click("button");
        sleep(1);
        await page.screenshot({ path: "screenshots/screenshot0.png" });
        await page.type("input[id='Username']", user.username);
        await page.type("input[id='Password']", user.password);
        await page.click("button");
        await page.screenshot({ path: "screenshots/screenshot1.png" });
        sleep(5);
        const authResponse = await page.evaluate(() => {
            return sessionStorage.getItem("auth_response");
        });
        const tokenInfo = JSON.parse(authResponse ?? "{}");
        await page.screenshot({ path: "screenshots/screenshot2.png" });
        console.log("LOGIN DONE FOR VU", vuID, user.username);
        page.close();
        ctx.close();
        return { tokenInfo };
    } catch (error) {
        console.log("LOGIN FAILED FOR VU", vuID, user.username);
        console.error(error);
        throw error;
    }
}
