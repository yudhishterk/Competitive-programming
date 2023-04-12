/**
 * https://leetcode.com/problems/backspace-string-compare/description/?envType=study-plan&id=algorithm-ii
 */
 
 
function backspaceCompare(s: string, t: string): boolean {
    let ssr = new StringReader(s);
    let tsr = new StringReader(t);

    let i = Math.min(s.length, t.length);

    while(--i >= 0 && ssr.getNext() === tsr.getNext()) {

    }

    return i < 0;
};

class StringReader{
    private str: string;
    private index: number;

    constructor(str: string) {
        this.str = str;
        this.index = this.str.length - 1;
    }

    public getNext(): string {
        let hashCount = 0;

        for(let i = this.index; i >= 0; i--) {
            if(this.str[i] === '#'){
                hashCount++;
                continue;
            }

            if(hashCount > 0) {
                hashCount--;
                continue;
            }

            this.index = i-1;
            return this.str[i];
        }

        return '';
    }
}
