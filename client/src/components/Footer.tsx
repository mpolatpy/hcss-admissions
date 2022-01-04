import React from "react";
import Divider from '@mui/material/Divider'
import Grid from "@mui/material/Grid";
import { Typography } from "@mui/material";

const Footer = () => (
    <div className="footer">
        <Grid container sx={{ textAlign: 'center', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
            <Grid item md={4} sm={12}>
                <img src="https://hampdencharter.org/wp-content/uploads/2019/11/logo-footer.png" />
            </Grid>
            <Grid item md={4} sm={12}>
                <h3>HCSS East</h3>
                <Typography variant="subtitle1">20 Johnson Rd. Chicopee, MA 01022</Typography>
                <Typography variant="subtitle1">Ph: (413) 593 9090</Typography>
                <Typography variant="subtitle1">Fax: (413) 294-2648</Typography>
                <Typography variant="subtitle1">info@hampdencharter.org</Typography>
            </Grid>
            <Grid item md={4} sm={12}>
                <h3>HCSS West</h3>
                <Typography variant="subtitle1">511 Main St. West Springfield, MA 01089</Typography>
                <Typography variant="subtitle1">Ph: (413) 278-5450</Typography>
                <Typography variant="subtitle1">Fax: (413) 278- 5387</Typography>
                <Typography variant="subtitle1">info@hampdencharter.org</Typography>
            </Grid>
            <Grid item md={12}>
                <h4>&copy; Hampden Charter School of Science</h4>
            </Grid>
        </Grid>
    </div>
);

export default Footer;