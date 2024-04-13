rem コマンドプロンプトで実行する。

rem 1、インポート対象のファイルを、DBサーバーへコピーする。

rem 2、bcp実行。

c:
cd C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\3_DB取込bcp

bcp FX_RealA.fxcm.T_Indicator_30m_EMA in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\EMA\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_KAMA in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\KAMA\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_LWMA in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\LWMA\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_MVA in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\MVA\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_PPMA in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\PPMA\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_SMMA in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\SMMA\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_TMA in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\TMA\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_VIDYA in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\VIDYA\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_WMA in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\WMA\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_ADX in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\ADX\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_DMI in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\DMI\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_AROON in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\AROON\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_ARSI in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\ARSI\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_HA in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\HA\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_ICH in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\ICH\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_MD in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\MD\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_REGRESSION in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\REGRESSION\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_SAR in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\SAR\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_CCI in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\CCI\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_CMO in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\CMO\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_MACD in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\MACD\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_OSC in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\OSC\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_RLW in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\RLW\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_ROC in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\ROC\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_RSI in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\RSI\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_SFK in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\SFK\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_STOCHASTIC in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\STOCHASTIC\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_KRI in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\KRI\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_TMACD in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\TMACD\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_TSI in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\TSI\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_PIVOT in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\PIVOT\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_AC in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\AC\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_ALLIGATOR in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\ALLIGATOR\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_AO in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\AO\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_FRACTAL in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\FRACTAL\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_GATOR in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\GATOR\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_BB in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\BB\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_ASI in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\ASI\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_ZIGZAG in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\ZIGZAG\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_ATR in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\ATR\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_EW in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\EW\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_EWN in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\EWN\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_EWO in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\EWO\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_MAE in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\MAE\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_AD in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\AD\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_CHO in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\CHO\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_CMF in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\CMF\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_OBV in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\OBV\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_SHIFT_I in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\SHIFT_I\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_SHIFT_O in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\SHIFT_O\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
bcp FX_RealA.fxcm.T_Indicator_30m_SHOWTIMETOEND in C:\work\3_Data\5_Indicator\5_30minutes\2_TSV形式\SHOWTIMETOEND\EUR_JPY.tsv -T -c -b 100000 >> bcp_in.log
