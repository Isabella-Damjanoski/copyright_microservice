// Function to generate a random phone number with the format +1XXXXXXXXXX
export function generateRandomPhoneNumber(): string {
    const areaCode = "555";
    const prefix = Math.floor(100 + Math.random() * 900); // 3-digit prefix
    const lineNumber = Math.floor(1000 + Math.random() * 9000); // 4-digit line number
    return `+1${areaCode}${prefix}${lineNumber}`;
}

// Function to add between 1 to 5 minutes to a timestamp
export function addRandomMinutes(timestamp: number): number {
    const randomMinutes = Math.floor(Math.random() * 5) + 1; // Random between 1 and 5 minutes
    return timestamp + randomMinutes * 60 * 1000;
}

// Function to calculate time-span between start and end timestamps in "HH:mm:ss" format
export function calculateTimeSpan(start: number, end: number): string {
    const diff = Math.max(end - start, 0); // Ensure non-negative difference
    const hours = String(Math.floor(diff / 3600000)).padStart(2, "0");
    const minutes = String(Math.floor((diff % 3600000) / 60000)).padStart(2, "0");
    const seconds = String(Math.floor((diff % 60000) / 1000)).padStart(2, "0");
    return `${hours}:${minutes}:${seconds}`;
}

// Function to randomly return one of the extracted IDs
const pcsUserIds = [
    "05b8cb97-2d00-4dc5-a167-18f0426e536e",
    "08893462-30fe-4018-b452-6cdc26791cf3",
    "15d74b95-9384-49e3-90f2-3e9b36e23684",
    "172de77b-d136-40e3-aeb3-4fc194155edd",
    "17cf74b7-3beb-4c9e-a67a-5044da1596da",
    "1bc8cb03-c2ca-43da-8bd3-b622a2743bb5",
    "1c0ffcb4-d9e7-46b8-bbea-ec369789475e",
    "1ca7b18c-4c08-4a5f-9b40-ac4bc1873df1",
    "1cdd8e58-1556-40f2-bb11-9540db60a460",
    "24b507e7-9cc0-4e22-8569-823ed254ced2",
];

export function getRandomPcsUserId(): string {
    const randomIndex = Math.floor(Math.random() * pcsUserIds.length);
    return pcsUserIds[randomIndex];
}
