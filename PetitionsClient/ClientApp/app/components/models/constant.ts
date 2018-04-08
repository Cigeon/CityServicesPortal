export class Constant {
    public static get VOTES_COUNT(): number { return 5 };
    public static get PETITIONS_STATUS(): string[] {
        return ['Перевірка', 'Збір голосів', 'Розглядається', 'З відповіддю', 'Не підтримано']
    };

    public static STATUS_COLOR(status: number): any {
        switch (status) {
            case 0:
                return '#c1afb1';
            case 1:
                return '#1ba1e2';
            case 2:
                return '#ffb410';
            case 3:
                return '#028900';
            case 4:
                return '#ff0065';
        }
    };

    public static STATUS_NAME(status: number): string {
        switch (status) {
            case 0:
                return 'Перевірка';
            case 1:
                return 'Збір голосів';
            case 2:
                return 'Розглядається';
            case 3:
                return 'З відповіддю';
            case 4:
                return 'Не підтримано';
            default:
                return '';
        }
    };

    public static STATUS_VALUE(name: string): number {
        switch (name) {
            case 'Перевірка':
                return 0;
            case 'Збір голосів':
                return 1;
            case 'Розглядається':
                return 2;
            case 'З відповіддю':
                return 3;
            case 'Не підтримано':
                return 4;
            default:
                return -1;
        }
    }
}