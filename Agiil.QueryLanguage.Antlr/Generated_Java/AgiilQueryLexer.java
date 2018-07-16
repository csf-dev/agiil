// Generated from /home/craig/Projects/Agiil/Agiil.QueryLanguage.Antlr/Tools/../AgiilQuery.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class AgiilQueryLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		OPENPAREN=1, CLOSEPAREN=2, EQUALS=3, NOTEQUALS=4, TILDE=5, COMMA=6, WHITESPACE=7, 
		NOT=8, AND=9, OR=10, NAME=11, WORD=12, DIGITS=13, QUOTEDVALUE=14, ANY=15;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"A", "D", "E", "H", "I", "K", "L", "N", "O", "R", "S", "T", "UPPERCASE", 
		"LOWERCASE", "DIGIT", "OPENPAREN", "CLOSEPAREN", "EQUALS", "NOTEQUALS", 
		"TILDE", "COMMA", "WHITESPACE", "NOT", "AND", "OR", "NAME", "WORD", "DIGITS", 
		"QUOTEDVALUE", "ANY"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'('", "')'", "'='", "'!='", "'~'", "','"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "OPENPAREN", "CLOSEPAREN", "EQUALS", "NOTEQUALS", "TILDE", "COMMA", 
		"WHITESPACE", "NOT", "AND", "OR", "NAME", "WORD", "DIGITS", "QUOTEDVALUE", 
		"ANY"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public AgiilQueryLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "AgiilQuery.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\21\u00a3\b\1\4\2"+
		"\t\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4"+
		"\13\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22"+
		"\t\22\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31"+
		"\t\31\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\3\2"+
		"\3\2\3\3\3\3\3\4\3\4\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\t\3\t\3\n\3\n\3"+
		"\13\3\13\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\20\3\20\3\21\3\21\3\22"+
		"\3\22\3\23\3\23\3\24\3\24\3\24\3\25\3\25\3\26\3\26\3\27\3\27\3\27\3\27"+
		"\5\27o\n\27\3\27\3\27\3\30\3\30\3\30\3\30\3\31\3\31\3\31\3\31\3\32\3\32"+
		"\3\32\3\33\3\33\3\33\5\33\u0081\n\33\3\33\3\33\3\33\3\33\6\33\u0087\n"+
		"\33\r\33\16\33\u0088\3\34\3\34\3\34\6\34\u008e\n\34\r\34\16\34\u008f\3"+
		"\35\6\35\u0093\n\35\r\35\16\35\u0094\3\36\3\36\3\36\3\36\7\36\u009b\n"+
		"\36\f\36\16\36\u009e\13\36\3\36\3\36\3\37\3\37\2\2 \3\2\5\2\7\2\t\2\13"+
		"\2\r\2\17\2\21\2\23\2\25\2\27\2\31\2\33\2\35\2\37\2!\3#\4%\5\'\6)\7+\b"+
		"-\t/\n\61\13\63\f\65\r\67\169\17;\20=\21\3\2\23\4\2CCcc\4\2FFff\4\2GG"+
		"gg\4\2JJjj\4\2KKkk\4\2MMmm\4\2NNnn\4\2PPpp\4\2QQqq\4\2TTtt\4\2UUuu\4\2"+
		"VVvv\3\2C\\\3\2c|\3\2\62;\4\2\13\13\"\"\4\2$$^^\2\u00a1\2!\3\2\2\2\2#"+
		"\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3"+
		"\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3\2\2\2\2\67\3\2\2\2\29\3\2\2\2"+
		"\2;\3\2\2\2\2=\3\2\2\2\3?\3\2\2\2\5A\3\2\2\2\7C\3\2\2\2\tE\3\2\2\2\13"+
		"G\3\2\2\2\rI\3\2\2\2\17K\3\2\2\2\21M\3\2\2\2\23O\3\2\2\2\25Q\3\2\2\2\27"+
		"S\3\2\2\2\31U\3\2\2\2\33W\3\2\2\2\35Y\3\2\2\2\37[\3\2\2\2!]\3\2\2\2#_"+
		"\3\2\2\2%a\3\2\2\2\'c\3\2\2\2)f\3\2\2\2+h\3\2\2\2-n\3\2\2\2/r\3\2\2\2"+
		"\61v\3\2\2\2\63z\3\2\2\2\65\u0080\3\2\2\2\67\u008d\3\2\2\29\u0092\3\2"+
		"\2\2;\u0096\3\2\2\2=\u00a1\3\2\2\2?@\t\2\2\2@\4\3\2\2\2AB\t\3\2\2B\6\3"+
		"\2\2\2CD\t\4\2\2D\b\3\2\2\2EF\t\5\2\2F\n\3\2\2\2GH\t\6\2\2H\f\3\2\2\2"+
		"IJ\t\7\2\2J\16\3\2\2\2KL\t\b\2\2L\20\3\2\2\2MN\t\t\2\2N\22\3\2\2\2OP\t"+
		"\n\2\2P\24\3\2\2\2QR\t\13\2\2R\26\3\2\2\2ST\t\f\2\2T\30\3\2\2\2UV\t\r"+
		"\2\2V\32\3\2\2\2WX\t\16\2\2X\34\3\2\2\2YZ\t\17\2\2Z\36\3\2\2\2[\\\t\20"+
		"\2\2\\ \3\2\2\2]^\7*\2\2^\"\3\2\2\2_`\7+\2\2`$\3\2\2\2ab\7?\2\2b&\3\2"+
		"\2\2cd\7#\2\2de\7?\2\2e(\3\2\2\2fg\7\u0080\2\2g*\3\2\2\2hi\7.\2\2i,\3"+
		"\2\2\2jo\t\21\2\2kl\7\17\2\2lo\7\f\2\2mo\7\f\2\2nj\3\2\2\2nk\3\2\2\2n"+
		"m\3\2\2\2op\3\2\2\2pq\b\27\2\2q.\3\2\2\2rs\5\21\t\2st\5\23\n\2tu\5\31"+
		"\r\2u\60\3\2\2\2vw\5\3\2\2wx\5\21\t\2xy\5\5\3\2y\62\3\2\2\2z{\5\23\n\2"+
		"{|\5\25\13\2|\64\3\2\2\2}\u0081\5\33\16\2~\u0081\5\35\17\2\177\u0081\7"+
		"a\2\2\u0080}\3\2\2\2\u0080~\3\2\2\2\u0080\177\3\2\2\2\u0081\u0086\3\2"+
		"\2\2\u0082\u0087\5\33\16\2\u0083\u0087\5\35\17\2\u0084\u0087\7a\2\2\u0085"+
		"\u0087\5\37\20\2\u0086\u0082\3\2\2\2\u0086\u0083\3\2\2\2\u0086\u0084\3"+
		"\2\2\2\u0086\u0085\3\2\2\2\u0087\u0088\3\2\2\2\u0088\u0086\3\2\2\2\u0088"+
		"\u0089\3\2\2\2\u0089\66\3\2\2\2\u008a\u008e\5\33\16\2\u008b\u008e\5\35"+
		"\17\2\u008c\u008e\7a\2\2\u008d\u008a\3\2\2\2\u008d\u008b\3\2\2\2\u008d"+
		"\u008c\3\2\2\2\u008e\u008f\3\2\2\2\u008f\u008d\3\2\2\2\u008f\u0090\3\2"+
		"\2\2\u00908\3\2\2\2\u0091\u0093\5\37\20\2\u0092\u0091\3\2\2\2\u0093\u0094"+
		"\3\2\2\2\u0094\u0092\3\2\2\2\u0094\u0095\3\2\2\2\u0095:\3\2\2\2\u0096"+
		"\u009c\7$\2\2\u0097\u009b\n\22\2\2\u0098\u0099\7^\2\2\u0099\u009b\t\22"+
		"\2\2\u009a\u0097\3\2\2\2\u009a\u0098\3\2\2\2\u009b\u009e\3\2\2\2\u009c"+
		"\u009a\3\2\2\2\u009c\u009d\3\2\2\2\u009d\u009f\3\2\2\2\u009e\u009c\3\2"+
		"\2\2\u009f\u00a0\7$\2\2\u00a0<\3\2\2\2\u00a1\u00a2\13\2\2\2\u00a2>\3\2"+
		"\2\2\f\2n\u0080\u0086\u0088\u008d\u008f\u0094\u009a\u009c\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}