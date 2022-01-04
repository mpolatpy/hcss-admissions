import * as React from 'react';
import Backdrop from '@mui/material/Backdrop';
import CircularProgress from '@mui/material/CircularProgress';
import Typography from '@mui/material/Typography';

interface Props {
    loading: boolean;
    content: string;
}

export default function Loader({loading, content}: Props) {

  return (
    <div>
      <Backdrop
        sx={{ backgroundColor: '#143355', color: '#fff', zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={loading}
      >
        <CircularProgress color="inherit" />
        <Typography variant="body2" ml={2}>{content}</Typography>
      </Backdrop>
    </div>
  );
}
