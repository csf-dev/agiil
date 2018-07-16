// Generated from /home/craig/Projects/Agiil/Agiil.QueryLanguage.Antlr/Tools/../AgiilQuery.g4 by ANTLR 4.7.1
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class AgiilQueryParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7.1", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		BOM=1, OPENPAREN=2, CLOSEPAREN=3, EQUALS=4, NOTEQUALS=5, TILDE=6, COMMA=7, 
		DOUBLEQUOTE=8, WHITESPACE=9, NOT=10, AND=11, OR=12, ORDERBY=13, DESCENDING=14, 
		ASCENDING=15, NAME=16, WORD=17, QUOTEDVALUE=18, ANY=19;
	public static final int
		RULE_search = 0, RULE_criteria = 1, RULE_logicalcriteriagroups = 2, RULE_criterionorgroup = 3, 
		RULE_criteriagroup = 4, RULE_criterion = 5, RULE_elementtest = 6, RULE_logicaloperator = 7, 
		RULE_element = 8, RULE_predicate = 9, RULE_predicatename = 10, RULE_value = 11, 
		RULE_constantvalue = 12, RULE_functioninvocation = 13, RULE_functionparameters = 14, 
		RULE_orders = 15, RULE_orderelement = 16;
	public static final String[] ruleNames = {
		"search", "criteria", "logicalcriteriagroups", "criterionorgroup", "criteriagroup", 
		"criterion", "elementtest", "logicaloperator", "element", "predicate", 
		"predicatename", "value", "constantvalue", "functioninvocation", "functionparameters", 
		"orders", "orderelement"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "'\uFEFF'", "'('", "')'", "'='", "'!='", "'~'", "','", "'\"'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, "BOM", "OPENPAREN", "CLOSEPAREN", "EQUALS", "NOTEQUALS", "TILDE", 
		"COMMA", "DOUBLEQUOTE", "WHITESPACE", "NOT", "AND", "OR", "ORDERBY", "DESCENDING", 
		"ASCENDING", "NAME", "WORD", "QUOTEDVALUE", "ANY"
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

	@Override
	public String getGrammarFileName() { return "AgiilQuery.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public AgiilQueryParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class SearchContext extends ParserRuleContext {
		public TerminalNode EOF() { return getToken(AgiilQueryParser.EOF, 0); }
		public TerminalNode BOM() { return getToken(AgiilQueryParser.BOM, 0); }
		public CriteriaContext criteria() {
			return getRuleContext(CriteriaContext.class,0);
		}
		public OrdersContext orders() {
			return getRuleContext(OrdersContext.class,0);
		}
		public SearchContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_search; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitSearch(this);
			else return visitor.visitChildren(this);
		}
	}

	public final SearchContext search() throws RecognitionException {
		SearchContext _localctx = new SearchContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_search);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(35);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==BOM) {
				{
				setState(34);
				match(BOM);
				}
			}

			setState(38);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==OPENPAREN || _la==NAME) {
				{
				setState(37);
				criteria();
				}
			}

			setState(41);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==ORDERBY) {
				{
				setState(40);
				orders();
				}
			}

			setState(43);
			match(EOF);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CriteriaContext extends ParserRuleContext {
		public LogicalcriteriagroupsContext logicalcriteriagroups() {
			return getRuleContext(LogicalcriteriagroupsContext.class,0);
		}
		public CriteriaContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_criteria; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitCriteria(this);
			else return visitor.visitChildren(this);
		}
	}

	public final CriteriaContext criteria() throws RecognitionException {
		CriteriaContext _localctx = new CriteriaContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_criteria);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(45);
			logicalcriteriagroups();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LogicalcriteriagroupsContext extends ParserRuleContext {
		public List<CriterionorgroupContext> criterionorgroup() {
			return getRuleContexts(CriterionorgroupContext.class);
		}
		public CriterionorgroupContext criterionorgroup(int i) {
			return getRuleContext(CriterionorgroupContext.class,i);
		}
		public List<LogicaloperatorContext> logicaloperator() {
			return getRuleContexts(LogicaloperatorContext.class);
		}
		public LogicaloperatorContext logicaloperator(int i) {
			return getRuleContext(LogicaloperatorContext.class,i);
		}
		public LogicalcriteriagroupsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logicalcriteriagroups; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitLogicalcriteriagroups(this);
			else return visitor.visitChildren(this);
		}
	}

	public final LogicalcriteriagroupsContext logicalcriteriagroups() throws RecognitionException {
		LogicalcriteriagroupsContext _localctx = new LogicalcriteriagroupsContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_logicalcriteriagroups);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(47);
			criterionorgroup();
			setState(54);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << OPENPAREN) | (1L << AND) | (1L << OR) | (1L << NAME))) != 0)) {
				{
				{
				setState(49);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==AND || _la==OR) {
					{
					setState(48);
					logicaloperator();
					}
				}

				setState(51);
				criterionorgroup();
				}
				}
				setState(56);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CriterionorgroupContext extends ParserRuleContext {
		public CriterionContext criterion() {
			return getRuleContext(CriterionContext.class,0);
		}
		public CriteriagroupContext criteriagroup() {
			return getRuleContext(CriteriagroupContext.class,0);
		}
		public CriterionorgroupContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_criterionorgroup; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitCriterionorgroup(this);
			else return visitor.visitChildren(this);
		}
	}

	public final CriterionorgroupContext criterionorgroup() throws RecognitionException {
		CriterionorgroupContext _localctx = new CriterionorgroupContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_criterionorgroup);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(59);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NAME:
				{
				setState(57);
				criterion();
				}
				break;
			case OPENPAREN:
				{
				setState(58);
				criteriagroup();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CriteriagroupContext extends ParserRuleContext {
		public TerminalNode OPENPAREN() { return getToken(AgiilQueryParser.OPENPAREN, 0); }
		public LogicalcriteriagroupsContext logicalcriteriagroups() {
			return getRuleContext(LogicalcriteriagroupsContext.class,0);
		}
		public TerminalNode CLOSEPAREN() { return getToken(AgiilQueryParser.CLOSEPAREN, 0); }
		public CriteriagroupContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_criteriagroup; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitCriteriagroup(this);
			else return visitor.visitChildren(this);
		}
	}

	public final CriteriagroupContext criteriagroup() throws RecognitionException {
		CriteriagroupContext _localctx = new CriteriagroupContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_criteriagroup);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(61);
			match(OPENPAREN);
			setState(62);
			logicalcriteriagroups();
			setState(63);
			match(CLOSEPAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class CriterionContext extends ParserRuleContext {
		public ElementContext element() {
			return getRuleContext(ElementContext.class,0);
		}
		public ElementtestContext elementtest() {
			return getRuleContext(ElementtestContext.class,0);
		}
		public CriterionContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_criterion; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitCriterion(this);
			else return visitor.visitChildren(this);
		}
	}

	public final CriterionContext criterion() throws RecognitionException {
		CriterionContext _localctx = new CriterionContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_criterion);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(65);
			element();
			setState(66);
			elementtest();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ElementtestContext extends ParserRuleContext {
		public PredicateContext predicate() {
			return getRuleContext(PredicateContext.class,0);
		}
		public ValueContext value() {
			return getRuleContext(ValueContext.class,0);
		}
		public FunctioninvocationContext functioninvocation() {
			return getRuleContext(FunctioninvocationContext.class,0);
		}
		public TerminalNode NOT() { return getToken(AgiilQueryParser.NOT, 0); }
		public ElementtestContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_elementtest; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitElementtest(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ElementtestContext elementtest() throws RecognitionException {
		ElementtestContext _localctx = new ElementtestContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_elementtest);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(75);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,7,_ctx) ) {
			case 1:
				{
				{
				setState(68);
				predicate();
				setState(69);
				value();
				}
				}
				break;
			case 2:
				{
				{
				setState(72);
				_errHandler.sync(this);
				_la = _input.LA(1);
				if (_la==NOT) {
					{
					setState(71);
					match(NOT);
					}
				}

				setState(74);
				functioninvocation();
				}
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LogicaloperatorContext extends ParserRuleContext {
		public TerminalNode AND() { return getToken(AgiilQueryParser.AND, 0); }
		public TerminalNode OR() { return getToken(AgiilQueryParser.OR, 0); }
		public LogicaloperatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_logicaloperator; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitLogicaloperator(this);
			else return visitor.visitChildren(this);
		}
	}

	public final LogicaloperatorContext logicaloperator() throws RecognitionException {
		LogicaloperatorContext _localctx = new LogicaloperatorContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_logicaloperator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(77);
			_la = _input.LA(1);
			if ( !(_la==AND || _la==OR) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ElementContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(AgiilQueryParser.NAME, 0); }
		public ElementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_element; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitElement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ElementContext element() throws RecognitionException {
		ElementContext _localctx = new ElementContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_element);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(79);
			match(NAME);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredicateContext extends ParserRuleContext {
		public PredicatenameContext predicatename() {
			return getRuleContext(PredicatenameContext.class,0);
		}
		public TerminalNode NOT() { return getToken(AgiilQueryParser.NOT, 0); }
		public PredicateContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predicate; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitPredicate(this);
			else return visitor.visitChildren(this);
		}
	}

	public final PredicateContext predicate() throws RecognitionException {
		PredicateContext _localctx = new PredicateContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_predicate);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(82);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==NOT) {
				{
				setState(81);
				match(NOT);
				}
			}

			setState(84);
			predicatename();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class PredicatenameContext extends ParserRuleContext {
		public TerminalNode EQUALS() { return getToken(AgiilQueryParser.EQUALS, 0); }
		public TerminalNode NOTEQUALS() { return getToken(AgiilQueryParser.NOTEQUALS, 0); }
		public TerminalNode TILDE() { return getToken(AgiilQueryParser.TILDE, 0); }
		public TerminalNode NAME() { return getToken(AgiilQueryParser.NAME, 0); }
		public PredicatenameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_predicatename; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitPredicatename(this);
			else return visitor.visitChildren(this);
		}
	}

	public final PredicatenameContext predicatename() throws RecognitionException {
		PredicatenameContext _localctx = new PredicatenameContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_predicatename);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(86);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << EQUALS) | (1L << NOTEQUALS) | (1L << TILDE) | (1L << NAME))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ValueContext extends ParserRuleContext {
		public ConstantvalueContext constantvalue() {
			return getRuleContext(ConstantvalueContext.class,0);
		}
		public FunctioninvocationContext functioninvocation() {
			return getRuleContext(FunctioninvocationContext.class,0);
		}
		public ValueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_value; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitValue(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ValueContext value() throws RecognitionException {
		ValueContext _localctx = new ValueContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_value);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(90);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,9,_ctx) ) {
			case 1:
				{
				setState(88);
				constantvalue();
				}
				break;
			case 2:
				{
				setState(89);
				functioninvocation();
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ConstantvalueContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(AgiilQueryParser.NAME, 0); }
		public TerminalNode NOT() { return getToken(AgiilQueryParser.NOT, 0); }
		public TerminalNode AND() { return getToken(AgiilQueryParser.AND, 0); }
		public TerminalNode OR() { return getToken(AgiilQueryParser.OR, 0); }
		public TerminalNode DESCENDING() { return getToken(AgiilQueryParser.DESCENDING, 0); }
		public TerminalNode ASCENDING() { return getToken(AgiilQueryParser.ASCENDING, 0); }
		public TerminalNode QUOTEDVALUE() { return getToken(AgiilQueryParser.QUOTEDVALUE, 0); }
		public List<TerminalNode> WORD() { return getTokens(AgiilQueryParser.WORD); }
		public TerminalNode WORD(int i) {
			return getToken(AgiilQueryParser.WORD, i);
		}
		public ConstantvalueContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constantvalue; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitConstantvalue(this);
			else return visitor.visitChildren(this);
		}
	}

	public final ConstantvalueContext constantvalue() throws RecognitionException {
		ConstantvalueContext _localctx = new ConstantvalueContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_constantvalue);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(104);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case NAME:
				{
				setState(92);
				match(NAME);
				}
				break;
			case NOT:
				{
				setState(93);
				match(NOT);
				}
				break;
			case AND:
				{
				setState(94);
				match(AND);
				}
				break;
			case OR:
				{
				setState(95);
				match(OR);
				}
				break;
			case WORD:
				{
				setState(97); 
				_errHandler.sync(this);
				_la = _input.LA(1);
				do {
					{
					{
					setState(96);
					match(WORD);
					}
					}
					setState(99); 
					_errHandler.sync(this);
					_la = _input.LA(1);
				} while ( _la==WORD );
				}
				break;
			case DESCENDING:
				{
				setState(101);
				match(DESCENDING);
				}
				break;
			case ASCENDING:
				{
				setState(102);
				match(ASCENDING);
				}
				break;
			case QUOTEDVALUE:
				{
				setState(103);
				match(QUOTEDVALUE);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctioninvocationContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(AgiilQueryParser.NAME, 0); }
		public TerminalNode OPENPAREN() { return getToken(AgiilQueryParser.OPENPAREN, 0); }
		public FunctionparametersContext functionparameters() {
			return getRuleContext(FunctionparametersContext.class,0);
		}
		public TerminalNode CLOSEPAREN() { return getToken(AgiilQueryParser.CLOSEPAREN, 0); }
		public FunctioninvocationContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functioninvocation; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitFunctioninvocation(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FunctioninvocationContext functioninvocation() throws RecognitionException {
		FunctioninvocationContext _localctx = new FunctioninvocationContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_functioninvocation);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(106);
			match(NAME);
			setState(107);
			match(OPENPAREN);
			setState(108);
			functionparameters();
			setState(109);
			match(CLOSEPAREN);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class FunctionparametersContext extends ParserRuleContext {
		public List<ValueContext> value() {
			return getRuleContexts(ValueContext.class);
		}
		public ValueContext value(int i) {
			return getRuleContext(ValueContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(AgiilQueryParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(AgiilQueryParser.COMMA, i);
		}
		public FunctionparametersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_functionparameters; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitFunctionparameters(this);
			else return visitor.visitChildren(this);
		}
	}

	public final FunctionparametersContext functionparameters() throws RecognitionException {
		FunctionparametersContext _localctx = new FunctionparametersContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_functionparameters);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(119);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NOT) | (1L << AND) | (1L << OR) | (1L << DESCENDING) | (1L << ASCENDING) | (1L << NAME) | (1L << WORD) | (1L << QUOTEDVALUE))) != 0)) {
				{
				setState(111);
				value();
				setState(116);
				_errHandler.sync(this);
				_la = _input.LA(1);
				while (_la==COMMA) {
					{
					{
					setState(112);
					match(COMMA);
					setState(113);
					value();
					}
					}
					setState(118);
					_errHandler.sync(this);
					_la = _input.LA(1);
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OrdersContext extends ParserRuleContext {
		public TerminalNode ORDERBY() { return getToken(AgiilQueryParser.ORDERBY, 0); }
		public List<OrderelementContext> orderelement() {
			return getRuleContexts(OrderelementContext.class);
		}
		public OrderelementContext orderelement(int i) {
			return getRuleContext(OrderelementContext.class,i);
		}
		public List<TerminalNode> COMMA() { return getTokens(AgiilQueryParser.COMMA); }
		public TerminalNode COMMA(int i) {
			return getToken(AgiilQueryParser.COMMA, i);
		}
		public OrdersContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_orders; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitOrders(this);
			else return visitor.visitChildren(this);
		}
	}

	public final OrdersContext orders() throws RecognitionException {
		OrdersContext _localctx = new OrdersContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_orders);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(121);
			match(ORDERBY);
			setState(122);
			orderelement();
			setState(127);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==COMMA) {
				{
				{
				setState(123);
				match(COMMA);
				setState(124);
				orderelement();
				}
				}
				setState(129);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class OrderelementContext extends ParserRuleContext {
		public TerminalNode NAME() { return getToken(AgiilQueryParser.NAME, 0); }
		public FunctioninvocationContext functioninvocation() {
			return getRuleContext(FunctioninvocationContext.class,0);
		}
		public TerminalNode ASCENDING() { return getToken(AgiilQueryParser.ASCENDING, 0); }
		public TerminalNode DESCENDING() { return getToken(AgiilQueryParser.DESCENDING, 0); }
		public OrderelementContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_orderelement; }
		@Override
		public <T> T accept(ParseTreeVisitor<? extends T> visitor) {
			if ( visitor instanceof AgiilQueryVisitor ) return ((AgiilQueryVisitor<? extends T>)visitor).visitOrderelement(this);
			else return visitor.visitChildren(this);
		}
	}

	public final OrderelementContext orderelement() throws RecognitionException {
		OrderelementContext _localctx = new OrderelementContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_orderelement);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(132);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,15,_ctx) ) {
			case 1:
				{
				setState(130);
				match(NAME);
				}
				break;
			case 2:
				{
				setState(131);
				functioninvocation();
				}
				break;
			}
			setState(135);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==DESCENDING || _la==ASCENDING) {
				{
				setState(134);
				_la = _input.LA(1);
				if ( !(_la==DESCENDING || _la==ASCENDING) ) {
				_errHandler.recoverInline(this);
				}
				else {
					if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
					_errHandler.reportMatch(this);
					consume();
				}
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3\25\u008c\4\2\t\2"+
		"\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\3\2\5\2&\n\2\3\2\5\2)\n\2\3\2\5\2,\n\2\3\2\3\2\3\3\3\3\3\4\3\4\5\4\64"+
		"\n\4\3\4\7\4\67\n\4\f\4\16\4:\13\4\3\5\3\5\5\5>\n\5\3\6\3\6\3\6\3\6\3"+
		"\7\3\7\3\7\3\b\3\b\3\b\3\b\5\bK\n\b\3\b\5\bN\n\b\3\t\3\t\3\n\3\n\3\13"+
		"\5\13U\n\13\3\13\3\13\3\f\3\f\3\r\3\r\5\r]\n\r\3\16\3\16\3\16\3\16\3\16"+
		"\6\16d\n\16\r\16\16\16e\3\16\3\16\3\16\5\16k\n\16\3\17\3\17\3\17\3\17"+
		"\3\17\3\20\3\20\3\20\7\20u\n\20\f\20\16\20x\13\20\5\20z\n\20\3\21\3\21"+
		"\3\21\3\21\7\21\u0080\n\21\f\21\16\21\u0083\13\21\3\22\3\22\5\22\u0087"+
		"\n\22\3\22\5\22\u008a\n\22\3\22\2\2\23\2\4\6\b\n\f\16\20\22\24\26\30\32"+
		"\34\36 \"\2\5\3\2\r\16\4\2\6\b\22\22\3\2\20\21\2\u0091\2%\3\2\2\2\4/\3"+
		"\2\2\2\6\61\3\2\2\2\b=\3\2\2\2\n?\3\2\2\2\fC\3\2\2\2\16M\3\2\2\2\20O\3"+
		"\2\2\2\22Q\3\2\2\2\24T\3\2\2\2\26X\3\2\2\2\30\\\3\2\2\2\32j\3\2\2\2\34"+
		"l\3\2\2\2\36y\3\2\2\2 {\3\2\2\2\"\u0086\3\2\2\2$&\7\3\2\2%$\3\2\2\2%&"+
		"\3\2\2\2&(\3\2\2\2\')\5\4\3\2(\'\3\2\2\2()\3\2\2\2)+\3\2\2\2*,\5 \21\2"+
		"+*\3\2\2\2+,\3\2\2\2,-\3\2\2\2-.\7\2\2\3.\3\3\2\2\2/\60\5\6\4\2\60\5\3"+
		"\2\2\2\618\5\b\5\2\62\64\5\20\t\2\63\62\3\2\2\2\63\64\3\2\2\2\64\65\3"+
		"\2\2\2\65\67\5\b\5\2\66\63\3\2\2\2\67:\3\2\2\28\66\3\2\2\289\3\2\2\29"+
		"\7\3\2\2\2:8\3\2\2\2;>\5\f\7\2<>\5\n\6\2=;\3\2\2\2=<\3\2\2\2>\t\3\2\2"+
		"\2?@\7\4\2\2@A\5\6\4\2AB\7\5\2\2B\13\3\2\2\2CD\5\22\n\2DE\5\16\b\2E\r"+
		"\3\2\2\2FG\5\24\13\2GH\5\30\r\2HN\3\2\2\2IK\7\f\2\2JI\3\2\2\2JK\3\2\2"+
		"\2KL\3\2\2\2LN\5\34\17\2MF\3\2\2\2MJ\3\2\2\2N\17\3\2\2\2OP\t\2\2\2P\21"+
		"\3\2\2\2QR\7\22\2\2R\23\3\2\2\2SU\7\f\2\2TS\3\2\2\2TU\3\2\2\2UV\3\2\2"+
		"\2VW\5\26\f\2W\25\3\2\2\2XY\t\3\2\2Y\27\3\2\2\2Z]\5\32\16\2[]\5\34\17"+
		"\2\\Z\3\2\2\2\\[\3\2\2\2]\31\3\2\2\2^k\7\22\2\2_k\7\f\2\2`k\7\r\2\2ak"+
		"\7\16\2\2bd\7\23\2\2cb\3\2\2\2de\3\2\2\2ec\3\2\2\2ef\3\2\2\2fk\3\2\2\2"+
		"gk\7\20\2\2hk\7\21\2\2ik\7\24\2\2j^\3\2\2\2j_\3\2\2\2j`\3\2\2\2ja\3\2"+
		"\2\2jc\3\2\2\2jg\3\2\2\2jh\3\2\2\2ji\3\2\2\2k\33\3\2\2\2lm\7\22\2\2mn"+
		"\7\4\2\2no\5\36\20\2op\7\5\2\2p\35\3\2\2\2qv\5\30\r\2rs\7\t\2\2su\5\30"+
		"\r\2tr\3\2\2\2ux\3\2\2\2vt\3\2\2\2vw\3\2\2\2wz\3\2\2\2xv\3\2\2\2yq\3\2"+
		"\2\2yz\3\2\2\2z\37\3\2\2\2{|\7\17\2\2|\u0081\5\"\22\2}~\7\t\2\2~\u0080"+
		"\5\"\22\2\177}\3\2\2\2\u0080\u0083\3\2\2\2\u0081\177\3\2\2\2\u0081\u0082"+
		"\3\2\2\2\u0082!\3\2\2\2\u0083\u0081\3\2\2\2\u0084\u0087\7\22\2\2\u0085"+
		"\u0087\5\34\17\2\u0086\u0084\3\2\2\2\u0086\u0085\3\2\2\2\u0087\u0089\3"+
		"\2\2\2\u0088\u008a\t\4\2\2\u0089\u0088\3\2\2\2\u0089\u008a\3\2\2\2\u008a"+
		"#\3\2\2\2\23%(+\638=JMT\\ejvy\u0081\u0086\u0089";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}