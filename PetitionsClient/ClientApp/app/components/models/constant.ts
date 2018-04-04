export class Constant {
    public static get VOTES_COUNT(): number { return 360 };
    public static get PETITIONS_STATUS(): string[] {
        return ['Перевірка', 'Збір голосів', 'Розглядається', 'З відповіддю', 'Не підтримано']
    };
}