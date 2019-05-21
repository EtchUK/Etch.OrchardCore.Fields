export const sortNumbers = (values: number[]): number[] => {
    return values.sort((a: number, b: number) => {
        return a - b;
    });
};
