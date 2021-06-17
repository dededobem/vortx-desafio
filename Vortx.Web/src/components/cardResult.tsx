import Grid from '@material-ui/core/Grid';
import { Typography } from '@material-ui/core';
import styles from '../../styles/cardResult.module.css';

const intlMonetary = new Intl.NumberFormat("pt-BR", {
    style: "currency",
    currency: "BRL",
    minimumFractionDigits: 2
});

export default function cardResult(props: any){
    return(
        <div className={styles.cardResult}>
            <div className={styles.section}>
                <Grid container alignItems="center" spacing={3}>
                <Grid item xs>
                    <Typography gutterBottom variant="h5">
                    Com Fale Mais
                    </Typography>
                </Grid>
                <Grid item>
                    <Typography gutterBottom variant="h4">
                        {intlMonetary.format(props.priceWithPlan)}
                    </Typography>
                </Grid>
                </Grid>                        
            </div>
            <div className={styles.section}>
                <Grid container alignItems="center" spacing={3}>
                <Grid item xs>
                    <Typography gutterBottom variant="h5">
                    Sem Fale Mais
                    </Typography>
                </Grid>
                <Grid item>
                    <Typography gutterBottom variant="h4">
                        {intlMonetary.format(props.priceWithoutPlan)}
                    </Typography>
                </Grid>
                </Grid>                        
            </div>
        </div>
    );
};
