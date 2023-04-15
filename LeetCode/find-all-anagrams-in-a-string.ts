/**
 * https://leetcode.com/problems/find-all-anagrams-in-a-string/description/
 */
 
function findAnagrams(s: string, p: string): number[] {
    if(s.length < p.length) {
        return [];
    }

    let pivot = p.length;
    let cc = new CharCounter();

    for(let ch of p) {
        cc.subChar(ch);
    }

    for(let i=0; i<pivot; i++) {
        cc.addChar(s[i]);
    }

    let result = [];
    for(let i=pivot; i<s.length; i++) {
        if(cc.isEmpty()) {
            result.push(i-pivot);
        }
        cc.subChar(s[i-pivot]);
        cc.addChar(s[i]);
    }

    if(cc.isEmpty()) {
        result.push(s.length-pivot);
    }

    return result;
};

class CharCounter {
    private static aAscii = "a".charCodeAt(0);

    chars: number[];
    count: number;

    constructor() {
        this.chars = new Array(26).fill(0);
        this.count = 0;
    }

    addChar(char: string) {
        let idx = char.charCodeAt(0) - CharCounter.aAscii;
        this.chars[idx]++;
        this.count++;
    }

    subChar(char: string) {
        let idx = char.charCodeAt(0) - CharCounter.aAscii;
        this.chars[idx]--;
        this.count--;
    }

    isEmpty(): Boolean {
        if(this.count !== 0) {
            return false;
        }

        return !this.chars.some(x => x !== 0);
    }
}
