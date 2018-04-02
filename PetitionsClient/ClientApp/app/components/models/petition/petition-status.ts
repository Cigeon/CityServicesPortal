export class PetitionStatus {
    public static get NAME(): string[] { return ['Перевірка', 'Збір голосів', 'Розглядається', 'З відповіддю'] };
    public static get COLOR(): string[] { return ["badge badge-secondary", "badge badge-primary", "badge badge-warning", "badge badge-success"] };
}