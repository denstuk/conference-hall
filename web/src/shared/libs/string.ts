export const cutString = (value: string, max: number): string => {
    if (value.length > max) {
        return value.slice(0, max - 3) + '...'; 
    }
    return value;
}