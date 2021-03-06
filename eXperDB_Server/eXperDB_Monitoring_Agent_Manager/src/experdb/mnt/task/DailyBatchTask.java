package experdb.mnt.task;

import java.sql.Connection;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import org.apache.ibatis.session.ExecutorType;
import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.log4j.Logger;

import experdb.mnt.db.mybatis.SqlSessionManager;

public class DailyBatchTask {

	protected static Logger log = Logger.getLogger(DailyBatchTask.class);	
	
	private String status = "2"; // 1:진행중 / 2:정상종료 / 3:오류
	private String comments = ""; // 오류세부 정보 : 0:데몬기동 / 1:접속종료 / 2:데이터삭제 / 3: VACUUM&ANALYZE /  4: 시퀀스초기화/ 5:인스턴스정보 UPDATE / 6: 접속수립 / 9:데몬종료
	private String reg_date = ""; // 오늘날짜
	
	public DailyBatchTask() {
		execute();
	}
	
	private void execute() {
		SqlSession sessionAgent  = null;
		
		try {
			// DB Connection을 가져온다
			sessionAgent = SqlSessionManager.getInstance().openSession();		

			Calendar cal = Calendar.getInstance();
			cal.setTime( new Date(System.currentTimeMillis()) );
			reg_date = new SimpleDateFormat("yyyyMMdd").format( cal.getTime());

			
			try {
				//TB_SYS_LOG 시작 insert
				HashMap<String, Object> insertMap = new HashMap<String, Object>();
				insertMap.put("reg_date", reg_date);
				
				sessionAgent.insert("app.TB_SYS_LOG_I001", insertMap);
				
				//Commit
				sessionAgent.commit();
			} catch (Exception e) {
				sessionAgent.rollback();
				log.error("", e);
				throw e;
			}			
			
			try {
				//Table Delete
				sessionAgent.delete("app.PGMONBT_BATCH_ACTV_COLLECT_INFO_001");
				sessionAgent.delete("app.PGMONBT_BATCH_CURRENT_LOCK_001");
				sessionAgent.delete("app.PGMONBT_BATCH_BACKEND_RSC_001");
				
				sessionAgent.delete("app.PGMONBT_BATCH_OBJT_COLLECT_INFO_001");
				sessionAgent.delete("app.PGMONBT_BATCH_ACCESS_INFO_001");
				sessionAgent.delete("app.PGMONBT_BATCH_TABLESPACE_INFO_001");
				sessionAgent.delete("app.PGMONBT_BATCH_TABLE_INFO_001");
				sessionAgent.delete("app.PGMONBT_BATCH_INDEX_INFO_001");
				
				sessionAgent.delete("app.PGMONBT_BATCH_RSC_COLLECT_INFO_001");
				sessionAgent.delete("app.PGMONBT_BATCH_MEMORY_STAT_001");
				sessionAgent.delete("app.PGMONBT_BATCH_CPU_STAT_MASTER_001");
				sessionAgent.delete("app.PGMONBT_BATCH_CPU_STAT_DETAIL_001");
				sessionAgent.delete("app.PGMONBT_BATCH_DISK_IO_001");
				sessionAgent.delete("app.PGMONBT_BATCH_DISK_USAGE_001");
				
				sessionAgent.delete("app.PGMONBT_BATCH_HCHK_COLLECT_INFO_001");
				sessionAgent.delete("app.PGMONBT_BATCH_SYS_LOG_001");
				
				//Commit
				sessionAgent.commit();
			} catch (Exception e) {
				sessionAgent.rollback();
				log.error("", e);
				
				status = "3";
				comments = "2";
			}
			
			sessionAgent.close();
			sessionAgent = SqlSessionManager.getInstance().openSession(ExecutorType.SIMPLE, true);
			
			try {
				//vacuum analyze
				sessionAgent.update("app.VACUUM_ANALYZE_U001");
				sessionAgent.update("app.VACUUM_ANALYZE_U002");
				sessionAgent.update("app.VACUUM_ANALYZE_U003");
				sessionAgent.update("app.VACUUM_ANALYZE_U006");
				sessionAgent.update("app.VACUUM_ANALYZE_U007");
				sessionAgent.update("app.VACUUM_ANALYZE_U008");
				sessionAgent.update("app.VACUUM_ANALYZE_U009");
				sessionAgent.update("app.VACUUM_ANALYZE_U010");
				sessionAgent.update("app.VACUUM_ANALYZE_U011");
				sessionAgent.update("app.VACUUM_ANALYZE_U012");
				sessionAgent.update("app.VACUUM_ANALYZE_U013");
				sessionAgent.update("app.VACUUM_ANALYZE_U014");
				sessionAgent.update("app.VACUUM_ANALYZE_U015");
				sessionAgent.update("app.VACUUM_ANALYZE_U016");
				sessionAgent.update("app.VACUUM_ANALYZE_U017");
				sessionAgent.update("app.VACUUM_ANALYZE_U018");
				sessionAgent.update("app.VACUUM_ANALYZE_U019");
				sessionAgent.update("app.VACUUM_ANALYZE_U020");
				sessionAgent.update("app.VACUUM_ANALYZE_U021");
			} catch (Exception e) {
				log.error("", e);
				
				status = "3";
				
				if(comments.equals("")) {
					comments = "3";
				} else{
					comments = comments + "|3";
				}
			}			
			
			if(comments.indexOf("2") < 0){
				try {
					sessionAgent.selectList("app.SEQ_SETVAL_001");
					sessionAgent.selectList("app.SEQ_SETVAL_002");
					sessionAgent.selectList("app.SEQ_SETVAL_003");
					sessionAgent.selectList("app.SEQ_SETVAL_004");
					
				} catch (Exception e) {
					log.error("", e);
					
					status = "3";
					
					if(comments.equals("")) {
						comments = "4";
					} else{
						comments = comments + "|4";
					}					
				}
			}

			
			//TB_SYS_LOG 정보 UPDATE
			HashMap<String, Object> updateMap = new HashMap<String, Object>();
			updateMap.put("status", status);
			updateMap.put("comments", comments);
			updateMap.put("reg_date", reg_date);
				
			sessionAgent.update("app.TB_SYS_LOG_U001", updateMap);
				
		} catch (Exception e) {
			log.error("", e);
		} finally {
			sessionAgent.close();
		}
	}
}
